window.showToastr = (type, message) => {

    if (!window.toastr) return;

    toastr.options.positionClass = "toast-top-right";

    switch (type) {
        case "success":
            toastr.success(message);
            break;
        case "error":
            toastr.error(message);
            break;
        case "info":
            toastr.info(message);
            break;
        case "warning":
            toastr.warning(message);
            break;
    }
};


function ShowConfirmationModal() {
    bootstrap.Modal
        .getOrCreateInstance(document.getElementById('bsConfirmationModal'))
        .show();
}

function HideConfirmationModal() {
    bootstrap.Modal
        .getOrCreateInstance(document.getElementById('bsConfirmationModal'))
        .hide();
}
