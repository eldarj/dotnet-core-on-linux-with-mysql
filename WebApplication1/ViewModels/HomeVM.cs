using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class HomeVM
    {
        public List<PostsListVM.ItemInfo> MainSlider { get; set; }
        public List<PostsListVM.ItemInfo> FeaturedSlides { get; set; }
        public List<PostsListVM.ItemInfo> ListOne { get; set; }
        public List<PostsListVM.ItemInfo> MainSliderPosts { get; set; }
        public List<PostsListVM.ItemInfo> PopularThumbs { get; set; }
        public List<PostsListVM.ItemInfo> GalleryThumbs { get; set; }
        public List<PostsListVM.ItemInfo> Latest { get; set; }
        public List<PostsListVM.ItemInfo> TopReviews { get; set; }
        public List<PostsListVM.ItemInfo> FeaturedSidebar { get; set; }
        public List<PostsListVM.ItemInfo> PopularSidebar { get; set; }
        public List<PostsListVM.ItemInfo> RecentSidebar { get; set; }

        public CategoriesListVM AllCategories { get; set; }
    }
}
