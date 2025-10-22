document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("clickButton");
    if (btn) {
        btn.addEventListener("click", function () {
            alert("Кнопка нажата!");
        });
    }
});
