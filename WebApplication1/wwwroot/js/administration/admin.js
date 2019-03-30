//function renderQuill() {
//    let toolbarOptions = [
//        ['bold', 'italic', 'underline', 'strike'],
//        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
//        [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
//        [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent

//        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
//        ['code-block', 'link', 'image'],

//        [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
//        [{ 'font': [] }],
//        [{ 'align': [] }],
//        ['clean']
//    ];
//    quill = new Quill('#quill-editor', {
//        modules: {
//            toolbar: toolbarOptions
//        },
//        theme: 'snow'
//    });
//}

function createDataTables() {
    $('.bs-datatable:not(.added)').DataTable({
        "pageLength": 5,
        "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, 'Prikaži sve']],
        "language": {
            "lengthMenu": "Prikaži _MENU_ zapisa po stranici",
            "zeroRecords": "Dogodila se greška ili lista traženih podataka je prazna!",
            "info": "Stranica _PAGE_ od ukupno _PAGES_",
            "infoEmpty": "0 pronađeno",
            "infoFiltered": "(od ukupno _MAX_ zapisa)",
            "search": "Pretraga:",
            "paginate": {
                "first": "Prvi",
                "last": "Posljednji",
                "next": "Sljedeći",
                "previous": "Prethodni"
            },
        }
    });
    $('.bs-datatable').addClass('added');
}

function addHandlers() {
    $('.divRow .closeDivRow').off().click(function () {
        $(this).closest('.divRow').prev('tr').css('background', 'transparent');
        $(this).closest('.divRow').remove();
    });
}

$(document).ready(function () {

    // Convert these to Boostrap datatables
    createDataTables();

    // Othe handlers
    addHandlers();

});

$(document).ajaxComplete(function () {

    // Convert these to Boostrap datatables
    createDataTables();

    // Othe handlers
    addHandlers();
});