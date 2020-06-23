export { drawRegisterScreen, coverRegisterDiv};

const registerDiv = document.createElement('div');
function drawRegisterScreen(registerFunction, saveRegisterFunction) {
    const registerBtn = document.createElement('button');
    registerBtn.innerText = 'register';
    registerBtn.addEventListener('click', registerFunction);
    document.body.appendChild(registerBtn);
        
    registerDiv.id = 'registerDiv';
    registerDiv.style.display = 'none';

    const registerIdLabel = document.createElement('label');
    registerIdLabel.innerText = 'Id';
    registerDiv.appendChild(registerIdLabel);

    const registerIdInput = document.createElement('input');
    registerIdInput.setAttribute('type', 'text');
    registerIdInput.placeholder = 'Id';
    registerIdInput.id = 'registerId';
    registerDiv.appendChild(registerIdInput);

    const registerPasswordLabel = document.createElement('label');
    registerPasswordLabel.innerText = 'Password';
    registerDiv.appendChild(registerPasswordLabel);

    const registerPasswordInput = document.createElement('input');
    registerPasswordInput.setAttribute('type', 'text');
    registerPasswordInput.placeholder = 'Password';
    registerPasswordInput.id = 'registerPassword';
    registerDiv.appendChild(registerPasswordInput);

    const registerUserNameLabel = document.createElement('label');
    registerUserNameLabel.innerText = 'User name';
    registerDiv.appendChild(registerUserNameLabel);

    const registerUserNameInput = document.createElement('input');
    registerUserNameInput.setAttribute('type', 'text');
    registerUserNameInput.placeholder = 'User name';
    registerUserNameInput.id = 'registerUserName';
    registerDiv.appendChild(registerUserNameInput);

    const saveRegisterBtn = document.createElement('button');
    saveRegisterBtn.innerText = 'Save register';
    saveRegisterBtn.addEventListener('click', saveRegisterFunction);
    registerDiv.appendChild(saveRegisterBtn);
    document.body.appendChild(registerDiv);

    document.body.appendChild(document.createElement('br'));
}

function coverRegisterDiv() {
    document.getElementById('registerDiv').style.display = 'none';
}