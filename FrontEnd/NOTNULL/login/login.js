const Iniciar = document.querySelector('#Iniciar');
const inicioSesion = document.querySelector('.inicioSesion');


Iniciar.addEventListener("click", e => {
    formRegister.classList.add("hide");
    window.location.href = "/FrontEnd/pacientes/paciente.html";
})

const boton = document.querySelector('#registrarB');//selecciona el elemento y lo almacena en boton
const botonRegistrar = document.querySelector('#registrarseB')
const registroD = document.querySelector('.registroD');
const registroUser = document.querySelector('.registroUser')

boton.addEventListener('click', ()=>{
    if(registroUser.classList.contains('oculto')){
        registroUser.classList.remove('oculto');
        registroD.classList.add('oculto')
    }
})

botonRegistrar.addEventListener('click', ()=>{   
    if(registroD.classList.contains('oculto')){
        registroD.classList.remove('oculto');
        registroUser.classList.add('oculto')
    }
})

function login(){
    var user, pass;

    user = document.querySelector("emailLogin").value;
    pass = document.getElementById("passwordLogin").value;

    if(user == "angedeveloper@gmail.com" && pass == "1232890241"){

        window.location= "paciente.html"

    }
}