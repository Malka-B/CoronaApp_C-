//title
const Title = document.createElement('title');
Title.innerText = 'Corona Virus- Epidimiologi Report';
document.body.appendChild(Title);

//h1
const helloTitle = document.createElement('h1');
helloTitle.innerText = 'Epidimiologi Report';
document.body.appendChild(helloTitle);

//loading event
document.body.addEventListener("load", onLoad());

//searching txtBoxes
//location
 const searchTxtByLocation = document.createElement('input');
searchTxtByLocation.setAttribute('id', 'searchPatientByLocation');
searchTxtByLocation.setAttribute('placeholder', 'searchPatientByLocation');
searchTxtByLocation.setAttribute('type', 'text');
document.body.appendChild(searchTxtByLocation);

//StartDate
const searchTxtStartDate = document.createElement('input');
searchTxtStartDate.setAttribute('id', 'searchPatientByDate_start');
searchTxtStartDate.setAttribute('placeholder', 'searchPatientByDate_start');
searchTxtStartDate.setAttribute('type', 'date');
document.body.appendChild(searchTxtStartDate);

//EndDate
const searchTxtEndDate = document.createElement('input');
searchTxtEndDate.setAttribute('id', 'searchPatientByDate_end');
searchTxtEndDate.setAttribute('placeholder', 'searchPatientByDate_end');
searchTxtEndDate.setAttribute('type', 'date');
document.body.appendChild(searchTxtEndDate);


//Age
const searchTxtAge = document.createElement('input');
searchTxtAge.setAttribute('id', 'searchPatientByAge');
searchTxtAge.setAttribute('placeholder', 'searchPatientByAge');
searchTxtAge.setAttribute('type', 'text');
document.body.appendChild(searchTxtAge);


//clickBtn
const searchBtn = document.createElement('input');
searchBtn.setAttribute('id', 'searchPatient');
searchBtn.setAttribute('value', 'search');
searchBtn.setAttribute('type', 'button');
document.body.appendChild(searchBtn);


//add click eventListener
const search = document.getElementById('searchPatient');
if (typeof search !== undefined) {
    search.addEventListener("click", function () {
        searchPatient();
    });
}

    function showDataFunc(localData) {
        const div = document.getElementById('dataDiv');
        div.innerText = '';
        var data = JSON.parse(localData);
        for (var i = 0; i < data.length; i++) {
            const li = document.createElement('li');
            li.innerText = data[i].startDate + " | " + data[i].endDate + " | " + data[i].adress + " | " + data[i].city;
            + " | " + data[i].patientId;
            div.appendChild(li);
        }
    }


function searchPatient() {
    const div = document.getElementById('dataDiv');
    div.innerText = '';
    const byDate_start = document.getElementById('searchPatientByDate_start');
    const byDate_end = document.getElementById('searchPatientByDate_end');
    const byLocation = document.getElementById('searchPatientByLocation');
    const byAge = document.getElementById('searchPatientByAge');

    if ((byDate_end == null || byDate_end.value == "")
        && (byDate_start == null || byDate_start.value == "")
        && (byLocation == null || byLocation.value == "")
        && (byAge == null || byAge.value==""))
        reastartData();
    else {
        let stringLocation = "";
        if (byLocation.value != "")
            stringLocation += "locationSearch.Location=" + byLocation.value;
        if (byDate_start.value != "") {
            if (stringLocation != "")
                stringLocation += "&locationSearch.StartDate=" + byDate_start.value;
            else
                stringLocation +="locationSearch.StartDate=" + byDate_start.value
        }
        if (byDate_end.value != "") {
            if (stringLocation != "")
                stringLocation+= "&locationSearch.EndDate=" + byDate_end.value;
            else
                stringLocation+= "locationSearch.EndDate=" + byDate_end.value
        if (byAge.value != "") {
                if (stringLocation != "")
                    stringLocation += "&locationSearch.Age=" + byAge.value;
                else
                    stringLocation += "locationSearch.Age=" + byAge.value
            }
        }
        let http = new XMLHttpRequest();
        http.onreadystatechange = function () {
            if (this.readyState == "4" && this.status == "200") {
                let myData = http.responseText;
                showDataFunc(myData);
            }
        }
        http.open("GET", "api/Location?" + stringLocation, true);
        http.send();
        byDate_end.value = "";
        byDate_start.value = "";
        byLocation.value = "";
    }
}


    function reastartData() {
        //xhttp
        let xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                let localData = xhttp.responseText;
                showDataFunc(localData);
            }
        }
        xhttp.open("GET", "api/Location/sort", true);
        xhttp.send();
    }


    function onLoad() {
        const div = document.createElement('div');
        div.setAttribute('id', 'dataDiv');
        div.setAttribute('innerHTML', '');
        document.body.appendChild(div);
        reastartData();
    }



