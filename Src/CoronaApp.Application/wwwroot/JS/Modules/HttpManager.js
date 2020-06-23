export class httpManager {
    constructor() {

    }



    static async get(url, userNameForCookies) {

        return await new Promise(function (resolve, reject) {
            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    resolve(xhttp.responseText);
                }

                else if (this.readyState == 4) {
                    if (typeof errorFunction === "function")
                        reject(this.response);
                }
            }

            xhttp.open("GET", url, true);
            xhttp.setRequestHeader('Authorization', 'Bearer ' + userNameForCookies);
            xhttp.send();
        });
    }

    static post(url, data, userNameForCookies) {

        return new Promise(function (resolve, reject) {
            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {

                if (this.readyState == 4 && this.status == 200) {

                    resolve(this.response);

                }

                else if (this.readyState == 4) {
                    if (typeof errorFunction === "function")
                        reject();

                }
            }
            xhttp.open("POST", url, true);
            xhttp.setRequestHeader('Content-Type', 'application/json');
            xhttp.setRequestHeader('Authorization', 'Bearer ' + userNameForCookies);

            xhttp.send(JSON.stringify(data));
        });
    }

    static put(url, data, successFunction, errorFunction) {

        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {

            if (this.readyState == 4 && this.status == 200) {

                successFunction();

            }

            else if (this.readyState == 4) {
                if (typeof errorFunction === "function")
                    errorFunction();

            }

            xhttp.open("PUT", url, true);

            xhttp.send(JSON.stringify(data));
        }

    }

    static delete(url, data, userNameForCookies) {
        debugger;
        return new Promise(function (response, reject) {
            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {

                if (this.readyState == 4 && this.status == 200) {

                    successFunction();

                }

                else if (this.readyState == 4) {
                    errorFunction();

                }

                xhttp.open("DELETE", url, true);
                xhttp.setRequestHeader('Content-Type', 'application/json');
                xhttp.setRequestHeader('Authorization', 'Bearer ' + userNameForCookies);
                xhttp.send(JSON.stringify(data));
            }
        });
    }
}
