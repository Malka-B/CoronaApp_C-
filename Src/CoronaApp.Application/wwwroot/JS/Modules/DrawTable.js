export { DrawTitles, displayTableElement, addTable, clearTable, getTableRowId}

let row = 0;

const bodyTableRows = document.createElement('tbody');
bodyTableRows.id = 'bodyTableRows';

const tableDiv = document.createElement('div');
tableDiv.style.display = 'none';

const locationsTable = document.createElement('table');

const bodyTable = document.createElement('tbody');

function DrawTitles(colValues, classForRow, classForCol) {    
    const tableRow = document.createElement('tr');
    tableRow.classList.add(classForRow);
    tableRow.id = row;
    for (let k = 0; k < colValues.length; k++) {
        const tableCol = document.createElement('th');
        tableCol.innerText = colValues[k];
        tableCol.classList.add(classForCol);
        tableRow.appendChild(tableCol);
    }
    bodyTable.appendChild(tableRow);
    row++;
    appendTableToBody();
}

function appendTableToBody() {
    locationsTable.appendChild(bodyTable);
    tableDiv.appendChild(locationsTable);
    document.body.appendChild(tableDiv);
}

function displayTableElement() {
    tableDiv.style.display = 'block';
}
function getTableRowId() {
    return row;
}
function addTable(patient, numberOfRows, removeRowFunction) {
    let current;
    for (let index = 0; index < numberOfRows; index++) {
        if (numberOfRows === 1) {
            current = patient;
        }
        else {
            current = patient[index];
        }
        const reportValues = [current.startDate, current.endDate, current.city, current.adress, 'x'];
        const tableRow = document.createElement('tr');
        tableRow.classList.add("tableRow");
        tableRow.id = row;
        for (let k = 0; k < reportValues.length; k++) {
            const currentRow = row;
            let tableCol = document.createElement('td');
            tableCol.innerText = reportValues[k];
            tableCol.id = k + ',' + currentRow;
            tableCol.classList.add("tableCol");
            if (k === 4) {
                tableCol = document.createElement('button');
                tableCol.innerText = 'x';
                tableCol.addEventListener("click", function () {
                    removeRowFunction(currentRow, current);
                });
            }
            tableRow.appendChild(tableCol);
        }
        bodyTableRows.appendChild(tableRow);
        row++;
    }
    locationsTable.appendChild(bodyTableRows);
}

function clearTable() {
    if (document.getElementById('bodyTableRows') != null) {
        document.getElementById('bodyTableRows').innerHTML = "";
    }
}