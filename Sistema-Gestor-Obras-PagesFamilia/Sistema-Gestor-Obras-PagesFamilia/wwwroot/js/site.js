document.addEventListener('DOMContentLoaded', function () {
    // Seleccionar primer rol por defecto en login si ninguno está marcado
    var roleRadios = document.querySelectorAll('.role-radio');
    if (roleRadios.length && !document.querySelector('.role-radio:checked')) {
        roleRadios[0].checked = true;
    }

    // Auto-ocultar alertas de éxito
    var successAlert = document.querySelector('.alert-success');
    if (successAlert) {
        setTimeout(function () {
            successAlert.style.transition = 'opacity 0.4s';
            successAlert.style.opacity = '0';
            setTimeout(function () { successAlert.remove(); }, 400);
        }, 4000);
    }
});
