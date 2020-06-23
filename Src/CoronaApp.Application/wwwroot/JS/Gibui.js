//'use strict'

//let row = 0;
//let userNameForCookies;
//let patientToSave = { id: "", age: "", locationsList: [] };


//const helloTitle = document.createElement('h1');
//helloTitle.innerText = 'Hello Epidemiological Report';
//document.body.appendChild(helloTitle);

//const reportTitle = document.createElement('h2');
//reportTitle.innerText = 'Report Your Path';
//document.body.appendChild(reportTitle);

//const welcomePatient = document.createElement('h2');
//welcomePatient.id = 'welcomePatient';
//welcomePatient.innerText = 'Welcome';
//document.body.appendChild(welcomePatient);

//const bodyTableRows = document.createElement('tbody');
//bodyTableRows.id = 'bodyTableRows';

//const buttonsDiv = document.createElement('div');

//const inputsDiv = document.createElement('div');

//const tableDiv = document.createElement('div');
//tableDiv.style.display = 'none';

//const locationsTable = document.createElement('table');

//const bodyTable = document.createElement('tbody');

//const userNameLabel = document.createElement('label');
//userNameLabel.innerText = 'User name';
//document.body.appendChild(userNameLabel);

//const userNameInput = document.createElement('input');
//userNameInput.setAttribute('type', 'text');
//userNameInput.placeholder = 'User name';
//userNameInput.id = 'userName';
//userNameInput.classList.add("locationInput");
//document.body.appendChild(userNameInput);

//document.body.appendChild(document.createElement('br'));

//const passwordLabel = document.createElement('label');
//passwordLabel.innerText = 'Password';
//document.body.appendChild(passwordLabel);

//const passwordInput = document.createElement('input');
//passwordInput.setAttribute('type', 'text');
//passwordInput.placeholder = 'Password';
//passwordInput.id = 'password';
//passwordInput.classList.add("locationInput");
//document.body.appendChild(passwordInput);

//document.body.appendChild(document.createElement('br'));

//const loginBtn = document.createElement('button');
//loginBtn.innerText = 'login';
//loginBtn.addEventListener('click', login);
//document.body.appendChild(loginBtn);

//const registerBtn = document.createElement('button');
//registerBtn.innerText = 'register';
//registerBtn.addEventListener('click', register);
//document.body.appendChild(registerBtn);

//const registerDiv = document.createElement('div');
//registerDiv.id = 'registerDiv';
//registerDiv.style.display = 'none';

//const registerIdLabel = document.createElement('label');
//registerIdLabel.innerText = 'Id';
//registerDiv.appendChild(registerIdLabel);

//const registerIdInput = document.createElement('input');
//registerIdInput.setAttribute('type', 'text');
//registerIdInput.placeholder = 'Id';
//registerIdInput.id = 'registerId';
//registerDiv.appendChild(registerIdInput);

//const registerPasswordLabel = document.createElement('label');
//registerPasswordLabel.innerText = 'Password';
//registerDiv.appendChild(registerPasswordLabel);

//const registerPasswordInput = document.createElement('input');
//registerPasswordInput.setAttribute('type', 'text');
//registerPasswordInput.placeholder = 'Password';
//registerPasswordInput.id = 'registerPassword';
//registerDiv.appendChild(registerPasswordInput);

//const registerUserNameLabel = document.createElement('label');
//registerUserNameLabel.innerText = 'User name';
//registerDiv.appendChild(registerUserNameLabel);

//const registerUserNameInput = document.createElement('input');
//registerUserNameInput.setAttribute('type', 'text');
//registerUserNameInput.placeholder = 'User name';
//registerUserNameInput.id = 'registerUserName';
//registerDiv.appendChild(registerUserNameInput);

//const saveRegisterBtn = document.createElement('button');
//saveRegisterBtn.innerText = 'Save register';
//saveRegisterBtn.addEventListener('click', saveRegister);
//registerDiv.appendChild(saveRegisterBtn);
//document.body.appendChild(registerDiv);

//document.body.appendChild(document.createElement('br'));

//const patientIdInput = document.createElement('input');
//patientIdInput.setAttribute('type', 'text');
//patientIdInput.placeholder = 'Patient ID';
//patientIdInput.id = 'PatientID';
//patientIdInput.classList.add("locationInput");
//patientIdInput.maxLength = 9;
//document.body.appendChild(patientIdInput);

//const getLocationsByIdBtn = document.createElement('button');
//getLocationsByIdBtn.innerText = 'Get locations';
//getLocationsByIdBtn.addEventListener('click', getLocationsById);
//document.body.appendChild(getLocationsByIdBtn);


//const colValues = ['Start date', 'End date', 'city', 'location', 'remove'];
//const tableRow = document.createElement('tr');
//tableRow.classList.add("tableRow");
//tableRow.id = row;
//for (let k = 0; k < colValues.length; k++) {
//    const tableCol = document.createElement('th');
//    tableCol.innerText = colValues[k];
//    tableCol.classList.add("tableCol");    
//    tableRow.appendChild(tableCol);
//}
//bodyTable.appendChild(tableRow);
//row++;

//const startDateInput = document.createElement('input');
//startDateInput.setAttribute('type', 'date');
//startDateInput.placeholder = 'Start date';
//startDateInput.id = 'startDateInput';
//setClassAndAppendToDiv(startDateInput);

//const endDateInput = document.createElement('input');
//endDateInput.setAttribute('type', 'date');
//endDateInput.placeholder = 'End date';
//endDateInput.id = 'endDateInput';
//setClassAndAppendToDiv(endDateInput);

//const cityInput = document.createElement('input');
//cityInput.setAttribute('type', 'text');
//cityInput.placeholder = 'City';
//cityInput.id = 'cityInput';
//setClassAndAppendToDiv(cityInput);

//const locationInput = document.createElement('input');
//locationInput.setAttribute('type', 'text');
//locationInput.placeholder = 'location';
//locationInput.id = 'locationInput';
//setClassAndAppendToDiv(locationInput);

//const ageInput = document.createElement('input');
//ageInput.setAttribute('type', 'text');
//ageInput.placeholder = 'Age';
//ageInput.id = 'ageInput';
//setClassAndAppendToDiv(ageInput);
//inputsDiv.style.display = 'none';

//const addLocationBtn = document.createElement('button');
//addLocationBtn.innerText = 'Add location';
//buttonsDiv.appendChild(addLocationBtn);
//addLocationBtn.addEventListener('click', addLocation);

//const saveLocationsBtn = document.createElement('button');
//saveLocationsBtn.innerText = 'Save locations';
//buttonsDiv.appendChild(saveLocationsBtn);

//buttonsDiv.style.display = 'none';
//saveLocationsBtn.addEventListener('click', saveLocations)

//locationsTable.appendChild(bodyTable);
//tableDiv.appendChild(locationsTable);
//document.body.appendChild(tableDiv);
//document.body.appendChild(inputsDiv);
//document.body.appendChild(buttonsDiv);

//function setClassAndAppendToDiv(inputToSet) {    
//    inputToSet.classList.add("locationInput");
//    inputsDiv.appendChild(inputToSet);
//}

////cookies
//function setCookie(name, value, days) {
//    var expires = "";
//    if (days) {
//        var date = new Date();
//        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
//        expires = "; expires=" + date.toUTCString();
//    }
//    document.cookie = name + "=" + (value || "") + expires + "; path=/";
//}

//function getCookie(name) {
//    var nameEQ = name + "=";
//    var ca = document.cookie.split(';');
//    for (var i = 0; i < ca.length; i++) {
//        var c = ca[i];
//        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
//        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
//    }
//    return null;
//}

//function eraseCookie(name) {
//    document.cookie = name + '=; Max-Age=-99999999;';
//}

//function login() {
//    const login = {
//        userName: document.getElementById('userName').value,
//        password: document.getElementById('password').value
//    }
//    var xhttp = new XMLHttpRequest();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {            
//            var token = JSON.parse(xhttp.responseText).token;
//            userNameForCookies = JSON.parse(xhttp.responseText).id;
//            setCookie(userNameForCookies, token, 7); 
//            clearFields(['userName', 'password']);            
//            getLocationsById();
//        }
//        else if (this.readyState == 4) {            
//            document.getElementById('welcomePatient').innerText += " sorry, you are not permitted use the system. Let's register now!";
//        }
//    }
//    xhttp.open("POST", "/api/Patient/loginAsync", true);
//    xhttp.setRequestHeader('Content-Type', 'application/json');
//    xhttp.send(JSON.stringify(login));
//}

//function clearFields(arr) {
//    for (var i = 0; i < arr.length; i++) {        
//        document.getElementById(arr[i]).value = "";
//    }
//}
//function register() {
//    document.getElementById('registerDiv').style.display = 'block';
//}

//function saveRegister() {
//    let register = {
//        id: parseInt(document.getElementById('registerId').value),
//        password: document.getElementById('registerPassword').value,
//        userName: document.getElementById('registerUserName').value
//    }
//    userNameForCookies = document.getElementById('registerId').value;
//    var xhttp = new XMLHttpRequest();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            clearFields(['registerId', 'registerPassword', 'registerUserName']);
//            document.getElementById('registerDiv').style.display = 'none';            
//            document.getElementById('PatientID').value = register.id;
//            let token = xhttp.responseText;            
//            setCookie(userNameForCookies, token, 7);            
//            getLocationsById();
//        }
//    }
//    xhttp.open("POST", "/api/Patient/register", true);
//    xhttp.setRequestHeader('Content-Type', 'application/json');
//    xhttp.send(JSON.stringify(register));    
//}

//function addLocation() {
//    let report = {
//        rowId: row,
//        id: document.getElementById('PatientID').value,
//        startDate: document.getElementById('startDateInput').value,
//        endDate: document.getElementById('endDateInput').value,
//        city: document.getElementById('cityInput').value,
//        adress: document.getElementById('locationInput').value
//    };
//    let location = {
//        startDate: document.getElementById('startDateInput').value,
//        endDate: document.getElementById('endDateInput').value,
//        city: document.getElementById('cityInput').value,
//        adress: document.getElementById('locationInput').value
//    };
//    patientToSave.id = parseInt(document.getElementById('PatientID').value);
//    patientToSave.age = parseInt(document.getElementById('ageInput').value);
//    patientToSave.locationsList.push(location);
//    document.getElementById('startDateInput').value = "";
//    document.getElementById('endDateInput').value = "";
//    document.getElementById('cityInput').value = "";
//    document.getElementById('locationInput').value = "";    
//    addTable(report, 1);
//};

//function getLocationsById() {    
//    let c = true;
//    if (c) {
//        clearTable();
//        c = false;
//    }
//    tableDiv.style.display = 'block';
//    inputsDiv.style.display = 'block';
//    buttonsDiv.style.display = 'block';
//    var xhttp = new XMLHttpRequest();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            var locations = JSON.parse(xhttp.responseText);
//            if (locations != null) {                
//                document.getElementById('ageInput').value = locations.age;
//                document.getElementById('PatientID').value = locations.id;
//                document.getElementById('welcomePatient').innerText = "Welcome " + locations.userName;
//                if (locations.locationsList.length == 1) {
//                    addTable(locations.locationsList[0], 1);
//                }
//                else {
//                    addTable(locations.locationsList, locations.locationsList.length);
//                }
//            }
//        }
//        if (this.status === 401) {
//            alert("you aren't permitted use the system");
//        }
//    };   
//    xhttp.open("GET", "/api/Patient", true);
//    if (userNameForCookies == null) {
//        userNameForCookies = document.getElementById('PatientID').value;
//    }
//    var x = getCookie(userNameForCookies);
//    if (x) {
//        xhttp.setRequestHeader('Authorization', 'Bearer ' + x);
//    }
//    xhttp.send();    
//}

//function saveLocations() {
//    if (patientToSave.id != "") {
//        var xhttp = new XMLHttpRequest();
//        xhttp.onreadystatechange = function () {
//            if (this.readyState == 4 && this.status == 200) {
//                clearTable();
//                clearFields(['PatientID', 'ageInput']);                
//            }
//        }
//        xhttp.open("POST", "/api/Patient", true);
//        xhttp.setRequestHeader('Content-Type', 'application/json');
//        var x = getCookie(userNameForCookies);        
//        if (x) {
//            xhttp.setRequestHeader('Authorization', 'Bearer ' + x);
//        }
//        xhttp.send(JSON.stringify(patientToSave));
//    }
//    else {
//        clearTable();
//        clearFields(['PatientID', 'ageInput']); 
//    }
//}

////לסדר
//function removeRow(rowNumber, patient) {
//    debugger;
//    let rowToDelete = document.getElementById(rowNumber);
//    rowToDelete.remove();    
//    var xhttp = new XMLHttpRequest();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            console.log("The location deleted successfully");
//        }
//        else {
//            console.log("error!");
//        }
//    }
//    xhttp.open("DELETE", "/api/Patient", true);
//    xhttp.setRequestHeader('Content-Type', 'application/json');
//    if (userNameForCookies == null) {
//        userNameForCookies = document.getElementById('PatientID').value;
//    }
//    var x = getCookie(userNameForCookies);
//    if (x) {
//        xhttp.setRequestHeader('Authorization', 'Bearer ' + x);
//    }
//    xhttp.send(JSON.stringify(patient));
//}

//function clearTable() {
//    if (document.getElementById('bodyTableRows') != null) {
//        document.getElementById('bodyTableRows').innerHTML = "";
//    }
//}

//function addTable(patient, numberOfRows) {
//    let current;
//    for (let index = 0; index < numberOfRows; index++) {
//        if (numberOfRows === 1) {
//            current = patient;
//        }
//        else {
//            current = patient[index];
//        }
//        const reportValues = [current.startDate, current.endDate, current.city, current.adress, 'x'];
//        const tableRow = document.createElement('tr');
//        tableRow.classList.add("tableRow");
//        tableRow.id = row;
//        for (let k = 0; k < reportValues.length; k++) {
//            const currentRow = row;
//            let tableCol = document.createElement('td');
//            tableCol.innerText = reportValues[k];
//            tableCol.id = k + ',' + currentRow;
//            tableCol.classList.add("tableCol");
//            if (k === 4) {
//                tableCol = document.createElement('button');
//                tableCol.innerText = 'x';
//                tableCol.addEventListener("click", function () {
//                    removeRow(currentRow, current);
//                });
//            }
//            tableRow.appendChild(tableCol);
//        }
//        bodyTableRows.appendChild(tableRow);
//        row++;
//    }
//    locationsTable.appendChild(bodyTableRows);
//}