const botonMostrarModal = document.getElementById("mostrarModal");
const modal = document.getElementById("modal");
const botonCerrarModal = document.getElementById("cerrarModal");

botonMostrarModal.addEventListener("click", () => {
    modal.classList.add("active");
});

botonCerrarModal.addEventListener("click", () => {
    modal.classList.remove("active");
});

window.addEventListener("click", (evento) => {
    if (evento.target === modal) {
        modal.classList.remove("active");
    }
});
