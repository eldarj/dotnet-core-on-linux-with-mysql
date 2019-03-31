using DataLib;
using DataLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public static class MyAuthHelper
    {
        private const string TOKEN_COOKIE = "USER_TKN";
        private const string LOGGED_IN_MOD = "LOGGED_IN_MOD";
        public const string LOGGED_IN_MOD_NAME = "LOGGED_IN_MOD_NAME";

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetLogiraniModerator(this HttpContext context, Moderator moderator, bool cookieLogin = false)
        {
            context.Session.Set(LOGGED_IN_MOD, moderator);
            if (cookieLogin)
            {
                MyContext db = context.RequestServices.GetService<MyContext>();

                string token = Guid.NewGuid().ToString();
                db.AuthTokens.Add(new AuthToken
                {
                    Value = token,
                    ModeratorId = moderator.UserID,
                    DateGenerated = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieToken(TOKEN_COOKIE, token);
            }
            else
            {
                context.Response.SetCookieToken(TOKEN_COOKIE, null);
            }
        }

        public static Moderator GetLogiranogModeratora(this HttpContext context)
        {
            Moderator x = context.Session.Get<Moderator>(LOGGED_IN_MOD);
            if (x == null)
            {
                string token = context.Request.GetCookiesToken(TOKEN_COOKIE);
                if (token == null)
                {
                    return null;
                }

                MyContext db = context.RequestServices.GetService<MyContext>();

                Moderator korisnik = db.AuthTokens
                    .Where(k => k.Value == token)
                    .Select(k => k.Moderator)
                    .SingleOrDefault();

                if (korisnik != null)
                {
                    context.Session.Set(LOGGED_IN_MOD, korisnik);
                    return korisnik;
                }
            }
            return x;
        }

        public static string GetCurrentToken(this HttpContext context)
        {
            return context.Request.GetCookiesToken(TOKEN_COOKIE);
        }

        public static void RemoveCurrentSession(this HttpContext context)
        {
            string token = context.Request.GetCookiesToken(TOKEN_COOKIE);

            MyContext db = context.RequestServices.GetService<MyContext>();
            AuthToken dbToken = db.AuthTokens.SingleOrDefault(t => t.Value == token);
            if (dbToken != null)
            {
                db.AuthTokens.Remove(dbToken);
                db.SaveChanges();
            }

            context.Response.Cookies.Delete(TOKEN_COOKIE);
            context.Session.Clear();
        }
    }
}
