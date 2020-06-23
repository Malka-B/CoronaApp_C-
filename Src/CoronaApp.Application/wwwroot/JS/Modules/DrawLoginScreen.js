export { drawLoginScreen };
import { createLoginInput } from "./DomInputs.js";
import { createLoginButton } from "./DomButtons.js";

function drawLoginScreen(loginFunction) {
    const helloTitle = document.createElement('h1');
    helloTitle.innerText = 'Hello Epidemiological Report';
    document.body.appendChild(helloTitle);

    const reportTitle = document.createElement('h2');
    reportTitle.innerText = 'Report Your Path';
    document.body.appendChild(reportTitle);

    const welcomePatient = document.createElement('h2');
    welcomePatient.id = 'welcomePatient';
    welcomePatient.innerText = 'Welcome';
    document.body.appendChild(welcomePatient);

    createLoginInput();

    createLoginButton(loginFunction);
}