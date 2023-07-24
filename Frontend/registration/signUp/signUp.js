document.addEventListener('DOMContentLoaded', function() {
    let input = document.querySelector('[name="email"].email-input');

    if (input) {
        input.value = localStorage.getItem("example-email") || "";

        input.addEventListener('input', function() {
            localStorage.setItem("example-email", this.value);
        });
    }
});