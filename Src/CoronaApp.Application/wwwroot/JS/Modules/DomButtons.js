export { createButtons, createPatientButton, displayDomButtons, createLoginButton };

const buttonsDiv = document.createElement('div');

function createButtons(addLocationFunction, saveLocationsFunction) {
    const addLocationBtn = document.createElement('button');
    addLocationBtn.innerText = 'Add location';
    buttonsDiv.appendChild(addLocationBtn);
    addLocationBtn.addEventListener('click', addLocationFunction);

    const saveLocationsBtn = document.createElement('button');
    saveLocationsBtn.innerText = 'Save locations';
    buttonsDiv.appendChild(saveLocationsBtn);

    buttonsDiv.style.display = 'none';
    saveLocationsBtn.addEventListener('click', saveLocationsFunction);
    document.body.appendChild(buttonsDiv);
}

function createPatientButton(getLocationsByIdFunction) {
    const getLocationsByIdBtn = document.createElement('button');
    getLocationsByIdBtn.innerText = 'Get locations';
    getLocationsByIdBtn.addEventListener('click', getLocationsByIdFunction);
    document.body.appendChild(getLocationsByIdBtn);
}

function createLoginButton(loginFunction) {
    const loginBtn = document.createElement('button');
    loginBtn.innerText = 'login';
    loginBtn.addEventListener('click', loginFunction);
    document.body.appendChild(loginBtn);
} 

function displayDomButtons() {
    buttonsDiv.style.display = 'block';
}
