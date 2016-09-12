$(function () {
    $(".category").on('click', function (e) {
        //var category = $(e.target).text();
        //var title = $('.action-title');


        //if (category.toUpperCase === "HOME")
        //    return;
        //else
        //    title.text(title.text + '->' + category);

    });

    $(".closeModal").click(function (e) {
        var modalId = $(e.target).attr('modal-name');
        $('#' + modalId).modal('hide');
    });

    //$('#toCartModal').modal();

    //$("#quantity").on('change', function (e) {
    //    var sess = Session["Cart"]

    //});
});