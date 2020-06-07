

//data
/*var data = [
{ patientId: '12345', startDate: '2020-05-01 12:00:00', endDate: '2020-05-03 12:00:00', city: 'Jerusalem', location: 'Library' },
{ patientId: '12346', startDate: '2020-03-01 12:00:00', endDate: '2020-03-03 12:00:00', city: 'Heifa', location: 'Restaurant' },
{ patientId: '12347', startDate: '2020-04-06 12:00:00', endDate: '2020-05-03 12:00:00', city: 'Givat-Zeev', location: 'Office' },
{ patientId: '12348', startDate: '2020-04-06 10:00:00', endDate: '2020-05-03 12:00:00', city: 'Tel-Aviv', location: 'Sea' },
{ patientId: '12349', startDate: '2020-05-08 12:00:00', endDate: '2020-05-03 12:00:00', city: 'Miron', location: 'Rashb"i' },
{ patientId: '12350', startDate: '2020-04-07 14:00:00', endDate: '2020-05-03 12:00:00', city: 'Beitar', location: 'Park' },
{ patientId: '12351', startDate: '2020-04-15 12:00:00', endDate: '2020-05-03 12:00:00', city: 'Beit-Shemesh', location: 'Garden' },
{ patientId: '12352', startDate: '2020-04-15 14:00:00', endDate: '2020-05-03 12:00:00', city: 'Jerusalem', location: 'Shul' },
{ patientId: '12353', startDate: '2020-03-28 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Elad', location: 'Super' },
{ patientId: '12354', startDate: '2020-03-28 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Zfat', location: 'Kinder-Garden' },
{ patientId: '12355', startDate: '2020-03-28 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Jerusalem', location: 'Market' },
{ patientId: '12356', startDate: '2020-03-15 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Raht', location: 'Park' },
{ patientId: '12357', startDate: '2020-04-18 06:00:00', endDate: '2020-05-03 12:00:00', city: 'Givat-Zeev', location: 'bus-stop' },
{ patientId: '12358', startDate: '2020-03-28 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Jerusalem', location: 'Market' },
{ patientId: '12359', startDate: '2020-03-17 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Arad', location: 'Dead-Sea' },
{ patientId: '12360', startDate: '2020-05-14 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Ofakim', location: 'Hotel' },
{ patientId: '12361', startDate: '2020-04-13 15:00:00', endDate: '2020-05-03 12:00:00', city: 'Modyin', location: 'Central-Station' },
{ patientId: '12362', startDate: '2020-03-22 09:00:00', endDate: '2020-05-03 12:00:00', city: 'Tiberia', location: 'School' },
{ patientId: '12363', startDate: '2020-03-25 11:00:00', endDate: '2020-05-03 12:00:00', city: 'Bnei-Brak', location: 'Super' },
{ patientId: '12364', startDate: '2020-03-28 00:00:00', endDate: '2020-05-03 12:00:00', city: 'Beit-Shemesh', location: 'Park' }];
*/
 


//title
const Title = document.createElement('title');
Title.innerText = 'Corona Virus- Epidimiologi Report';
document.body.appendChild(Title);

//h1
const helloTitle = document.createElement('h1');
helloTitle.innerText = 'Epidimiologi Report';
document.body.appendChild(helloTitle);

//loading event
document.body.addEventListener("load", onLoading());


//searching txtBox
const searchTxt = document.createElement('input');
searchTxt.setAttribute('type', 'text');
searchTxt.setAttribute('id', 'searchCityByName');
document.body.appendChild(searchTxt);
const searchEvent = document.getElementById('searchCityByName');
if (typeof searchEvent !== undefined) {
    searchEvent.addEventListener("keyup", function () {
        if (event.keyCode === 13)
            searchCityFunc();
        else if (!event.target.value)
            reastartData();
    });
}


function showDataFunc(localData) {
    const div = document.getElementById('dataDiv');
    div.innerText = '';
    var data = JSON.parse(localData);
    for (var i = 0; i < data.length; i++) {
        const li = document.createElement('li');
        li.innerText = data[i].startDate + " | " + data[i].location + " | " + data[i].city
            + " | " + data[i].patientId;
        div.appendChild(li);
    }
}


function searchCityFunc() {
    const div = document.getElementById('dataDiv');
    div.innerText = '';
    if (event.target.value) {
        let http = new XMLHttpRequest();
        http.onreadystatechange = function () {
            if (this.readyState == "4" && this.status == "200") {
                let myData = http.responseText;
                showDataFunc(myData);
            }
        }
        http.open("GET", "Patient?city=" + event.target.value, true);
        http.send();
    }
    else reastartData();
    /*const filterData = [];
    for (var i = 0; i < data.length; i++)
        if (data[i].city.toLowerCase().includes(event.target.value.toLowerCase()))
            filterData.push(data[i]);
    for (var i = 0; i < filterData.length; i++) {
         const p=document.createElement('p');
         p.innerText=filterData[i].startDate + " | " +
         filterData[i].location + " | " + filterData[i].city+" | "
         +filterData[i].patientId;
         document.getElementById("dataDiv").appendChild(p);*/
}



function reastartData() {
    //xhttp
    let promise = new Promise(resolve, reject){
    let xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let localData = xhttp.responseText;
            showDataFunc(localData);
        }}
    }
    xhttp.open("GET", "Patient/sort", true);
    xhttp.send();
}


function onLoading() {
    const div = document.createElement('div');
    div.setAttribute('id', 'dataDiv');
    div.setAttribute('innerHTML', '');
    document.body.appendChild(div);
    reastartData();
}



  /* data.sort(function (a, b) {
        const dateA = new Date(a.startDate),
            dateB = new Date(b.startDate);
        return dateB - dateA;
    })
    for (var i = 0; i < data.length; i++) {
        const li=document.createElement('li');
        li.innerText=data[i].startDate + " | " + data[i].location + " | " + data[i].city
        +" | "+ data[i].patientId;
        document.getElementById("dataDiv").appendChild(li);*/



