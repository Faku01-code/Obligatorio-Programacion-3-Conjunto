function dismissToast() {
    var toast = document.getElementById('appToast');
    if (!toast) return;
    toast.classList.add('hiding');
    setTimeout(function () { toast.remove(); }, 280);
}

document.addEventListener('DOMContentLoaded', function () {
    // Seleccionar primer rol por defecto en login si ninguno está marcado
    var roleRadios = document.querySelectorAll('.role-radio');
    if (roleRadios.length && !document.querySelector('.role-radio:checked')) {
        roleRadios[0].checked = true;
    }

    // Auto-ocultar toast de éxito
    var toast = document.getElementById('appToast');
    if (toast) {
        setTimeout(function () { dismissToast(); }, 4000);
    }

    // Page loader: ocultar tras 1.5s en cada carga de página
    var loader = document.getElementById('pageLoader');
    if (loader) {
        setTimeout(function () {
            loader.classList.add('is-hidden');
        }, 1500);

        // Mostrar loader al navegar hacia otra página
        document.addEventListener('click', function (e) {
            var link = e.target.closest('a[href]');
            if (!link) return;
            var href = link.getAttribute('href');
            if (!href || href.startsWith('#') || href.startsWith('javascript') || href.startsWith('mailto')) return;
            if (link.target === '_blank') return;
            if (link.classList.contains('disabled')) return;
            loader.classList.remove('is-hidden');
            loader.style.opacity = '1';
        });
    }

    // Login: mostrar spinner en el botón al enviar si el formulario es válido
    var loginForm = document.querySelector('.login-form');
    if (loginForm) {
        loginForm.addEventListener('submit', function () {
            setTimeout(function () {
                var hasErrors = loginForm.querySelector('.field-validation-error') !== null;
                if (hasErrors) return;
                var btn = document.getElementById('loginBtn');
                if (!btn || btn.disabled) return;
                btn.disabled = true;
                btn.innerHTML = '<span class="btn-spinner"></span> Ingresando...';
            }, 50);
        });
    }
});
