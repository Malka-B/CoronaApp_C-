import { httpManager } from "./Modules/HttpManager.js";
import { setCookie, getCookie } from "./Modules/Cookies.js";
import { drawLoginScreen } from "./Modules/DrawLoginScreen.js";
import { drawRegisterScreen, coverRegisterDiv } from "./Modules/DrawRegisteScreen.js";
import { DrawTitles, displayTableElement, addTable, clearTable, getTableRowId } from "./Modules/DrawTable.js";
import { createButtons, createPatientButton, displayDomButtons } from "./Modules/DomButtons.js";
import { createInputs, displayDomInput, createPatientInput, clearFields, setPatientIdAfterRegister } from "./Modules/DomInputs.js";

'use strict'

let userNameForCookies;

let patientToSave = { id: "", age: "", locationsList: [] };

drawLoginScreen(login);
drawRegisterScreen(register, saveRegister);
createPatientInput(getLocationsById);
createPatientButton(getLocationsById);
const colValues = ['Start date', 'End date', 'city', 'location', 'remove'];
DrawTitles(colValues, "tableRow", "tableCol");
createInputs();

createButtons(addLocation, saveLocations);

function login() {
    const login = {
        userName: document.getElementById('userName').value,
        password: document.getElementById('password').value
    }
    try {
        httpManager.post("/api/Patient/loginAsync", login, null).
            then(function (response) {
                var token = JSON.parse(response).token;
                userNameForCookies = JSON.parse(response).id;
                setCookie(userNameForCookies, token, 7);
                clearFields(['userName', 'password']);
                getLocationsById();
            });
    }
    catch{
        document.getElementById('welcomePatient').innerText += " sorry, you are not permitted use the system. Let's register now!";
    }

}

function register() {
    document.getElementById('registerDiv').style.display = 'block';
}

function saveRegister() {
    let register = {
        id: parseInt(document.getElementById('registerId').value),
        password: document.getElementById('registerPassword').value,
        userName: document.getElementById('registerUserName').value
    }
    userNameForCookies = document.getElementById('registerId').value;
    httpManager.post("/api/Patient/register", register, null).
        then(function (response) {
            clearFields(['registerId', 'registerPassword', 'registerUserName']);
            coverRegisterDiv();
            setPatientIdAfterRegister(register.id);            
            let token = response;
            setCookie(userNameForCookies, token, 7);
            getLocationsById();
        });
}

function addLocation() {
    let report = {
        rowId: getTableRowId(),
        id: document.getElementById('PatientID').value,
        startDate: document.getElementById('startDateInput').value,
        endDate: document.getElementById('endDateInput').value,
        city: document.getElementById('cityInput').value,
        adress: document.getElementById('locationInput').value
    };
    let location = {
        startDate: document.getElementById('startDateInput').value,
        endDate: document.getElementById('endDateInput').value,
        city: document.getElementById('cityInput').value,
        adress: document.getElementById('locationInput').value
    };
    patientToSave.id = parseInt(document.getElementById('PatientID').value);
    patientToSave.age = parseInt(document.getElementById('ageInput').value);
    patientToSave.locationsList.push(location);
    clearFields(['startDateInput', 'endDateInput', 'cityInput', 'locationInput']);    
    addTable(report, 1, removeRow);
};

function getLocationsById() {
    let c = true;
    if (c) {
        clearTable();
        c = false;
    }


    try {
        if (document.getElementById('PatientID').value !== "") {
            if (userNameForCookies === null || userNameForCookies !== document.getElementById('PatientID').value) {
                userNameForCookies = document.getElementById('PatientID').value;
            }
        }
        var x = getCookie(userNameForCookies);
        if (x === null) {
            throw new DOMException();
        }
        httpManager.get("/api/Patient", x).then(function (response) {
            var locations = JSON.parse(response);
            if (locations != null) {
                document.getElementById('ageInput').value = locations.age;
                document.getElementById('PatientID').value = locations.id;
                document.getElementById('welcomePatient').innerText = "Welcome " + locations.userName;
                displayTableElement();
                displayDomInput();
                displayDomButtons();                
                if (locations.locationsList.length == 1) {
                    addTable(locations.locationsList[0], 1, removeRow);
                }
                else {
                    addTable(locations.locationsList, locations.locationsList.length, removeRow);
                }
            }
        });
    }
    catch{
        document.getElementById('welcomePatient').innerText += " sorry, you are not permitted use the system. Let's register now!"
    }
}

function saveLocations() {
    if (patientToSave.id != "") {
        try {
            userNameForCookies = document.getElementById('PatientID').value;
            var x = getCookie(userNameForCookies);
            if (x === null) {
                throw new DOMException();
            }
            httpManager.post("/api/Patient", patientToSave, x)
                .then(function (response) {
                    clearTable();
                    clearFields(['PatientID', 'ageInput']);

                });
        }
        catch{
            alert("Error! Try again");
        }
    }
}

//???????????לסדר
function removeRow(rowNumber, current) {
    debugger;
    let rowToDelete = document.getElementById(rowNumber);
    rowToDelete.remove();
    try {
        userNameForCookies = document.getElementById('PatientID').value;
        var x = getCookie(userNameForCookies);
        if (x === null) {
            throw new DOMException();
        }
        httpManager.delete("/api/Patient", patient, x)
            .then(function (response) {
                console.log("The location deleted successfully");
            });
    }
    catch{

    }
    //var xhttp = new XMLHttpRequest();
    //xhttp.onreadystatechange = function () {
    //    if (this.readyState == 4 && this.status == 200) {
    //        console.log("The location deleted successfully");
    //    }
    //    else {
    //        console.log("error!");
    //    }
    //}
    //xhttp.open("DELETE", "/api/Patient", true);
    //xhttp.setRequestHeader('Content-Type', 'application/json');
    //if (userNameForCookies == null) {
    //    userNameForCookies = document.getElementById('PatientID').value;
    //}
    //var x = getCookie(userNameForCookies);
    //if (x) {
    //    xhttp.setRequestHeader('Authorization', 'Bearer ' + x);
    //}
    //xhttp.send(JSON.stringify(patient));
}


