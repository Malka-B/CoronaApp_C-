export { createInputs, displayDomInput, createPatientInput, clearFields, drawLoginInput, createLoginInput, setPatientIdAfterRegister };


const inputsDiv = document.createElement('div');
const userNameInput = document.createElement('input');
const passwordInput = document.createElement('input');
const userNameLabel = document.createElement('label');
const passwordLabel = document.createElement('label');
const patientIdInput = document.createElement('input');
const startDateInput = document.createElement('input');
const endDateInput = document.createElement('input');
const cityInput = document.createElement('input');
const locationInput = document.createElement('input');
const ageInput = document.createElement('input');


function createLoginInput() {
    
    userNameLabel.innerText = 'User name';
    document.body.appendChild(userNameLabel);
   
    userNameInput.setAttribute('type', 'text');
    userNameInput.placeholder = 'User name';
    userNameInput.id = 'userName';
    userNameInput.classList.add("locationInput");
    document.body.appendChild(userNameInput);

    document.body.appendChild(document.createElement('br'));
        
    passwordLabel.innerText = 'Password';
    document.body.appendChild(passwordLabel);
    
    passwordInput.setAttribute('type', 'text');
    passwordInput.placeholder = 'Password';
    passwordInput.id = 'password';
    passwordInput.classList.add("locationInput");
    document.body.appendChild(passwordInput);

    document.body.appendChild(document.createElement('br'));
}
function createPatientInput() {
    
    patientIdInput.setAttribute('type', 'text');
    patientIdInput.placeholder = 'Patient ID';
    patientIdInput.id = 'PatientID';
    patientIdInput.classList.add("locationInput");
    patientIdInput.maxLength = 9;
    document.body.appendChild(patientIdInput);
        
}
function createInputs() {   
       
    startDateInput.setAttribute('type', 'date');
    startDateInput.placeholder = 'Start date';
    startDateInput.id = 'startDateInput';
    setInputClass(startDateInput);
    AppendInputToDiv(startDateInput);

    endDateInput.setAttribute('type', 'date');
    endDateInput.placeholder = 'End date';
    endDateInput.id = 'endDateInput';
    setInputClass(endDateInput);
    AppendInputToDiv(endDateInput);
    
    cityInput.setAttribute('type', 'text');
    cityInput.placeholder = 'City';
    cityInput.id = 'cityInput';
    setInputClass(cityInput);
    AppendInputToDiv(cityInput);
   
    locationInput.setAttribute('type', 'text');
    locationInput.placeholder = 'location';
    locationInput.id = 'locationInput';
    setInputClass(locationInput);
    AppendInputToDiv(locationInput);
    
    ageInput.setAttribute('type', 'text');
    ageInput.placeholder = 'Age';
    ageInput.id = 'ageInput';
    setInputClass(ageInput);
    AppendInputToDiv(ageInput);
    inputsDiv.style.display = 'none';
    document.body.appendChild(inputsDiv);
}

function setInputClass(inputToSet) {
    inputToSet.classList.add("locationInput");    
}

function AppendInputToDiv(inputToSet) {    
    inputsDiv.appendChild(inputToSet);
}

function displayDomInput() {
    inputsDiv.style.display = 'block';
}

function clearFields(arr) {
    for (var i = 0; i < arr.length; i++) {
        document.getElementById(arr[i]).value = "";
    }
}

function drawLoginInput() {    
    userNameInput.setAttribute('type', 'text');
    userNameInput.placeholder = 'User name';
    userNameInput.id = 'userName';
    userNameInput.classList.add("locationInput");
    document.body.appendChild(userNameInput);
}

function setPatientIdAfterRegister(registerId) {
    document.getElementById('PatientID').value = registerId;
}