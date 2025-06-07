// Fonction pour mettre à jour le nombre d'articles dans le panier
function updateCartCount() {
    fetch('/Cart/GetCartCount')
        .then(response => response.json())
        .then(data => {
            document.getElementById('cartCount').textContent = data.count;
        });
}

// Mettre à jour le panier au chargement de la page
document.addEventListener('DOMContentLoaded', function() {
    updateCartCount();
    
    // Activer les tooltips Bootstrap
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
    
    // Gestion des messages temporaires
    setTimeout(function() {
        var alerts = document.querySelectorAll('.alert');
        alerts.forEach(function(alert) {
            var bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        });
    }, 5000);
});

// Gestion de la soumission des formulaires avec confirmation
document.querySelectorAll('form[data-confirm]').forEach(form => {
    form.addEventListener('submit', function(e) {
        if (!confirm(this.getAttribute('data-confirm'))) {
            e.preventDefault();
        }
    });
});