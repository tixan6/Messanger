$(document).ready(function () {

    $(".modal-link").on("click", function () {
        $('.modal-overlay[data-modal="' + $(this).data('modal') + '"]').addClass("modal-overlay_visible");
    });

    $(".modal__close").on("click", function () {
        $(".modal-overlay").removeClass("modal-overlay_visible");
    });

    $(document).on("click", function (e) {
        if ($(".modal-overlay_visible").length) {
            if (!$(e.target).closest(".modal").length && !$(e.target).closest(".modal-link").length) {
                $(".modal-overlay").removeClass("modal-overlay_visible");
            }
        }
    });
});

