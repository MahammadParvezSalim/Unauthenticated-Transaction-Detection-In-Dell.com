// ==UserScript==
// @name         Script to capture user visited pages
// @namespace    dell.com
// @version      0.1
// @description  Script to capture user visited pages
// @author       UHCL Capstone Team
// @match        https://www.dell.com/*
// @grant        none
// MODIFICATION HISTORY
// WHO      WHEN          WHAT
// Ha Vu    09/23/2019    Initial Version
// Ha Vu    10/03/2019    Add get methods for all the fields
// ==/UserScript==
//debugger;


const uri = "http://localhost:44340/api/home";

function formatDate(date) {
    return date.getFullYear() + '/' +
        (date.getMonth() + 1) + '/' +
        date.getDate() + ' ' +
        date.getHours() + ':' +
        date.getMinutes() + ':' +
        date.getSeconds();
}

function getUTCDateTime() {
    var date = new Date();
    var now_utc = Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(),
        date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());

    return new Date(now_utc);
}

function getFullURL() {
    return window.location.href;
}

function getPathName() {
    return location.pathname;
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

function getReferer() {
    var referer = "";
    try {
        referer = document.referrer;
        //Navigate from within dell.com
        if (referer.indexOf("https://www.dell.com") >= 0) {
            referer = "";
        }
    }
    catch (err) {
        referer = "";
        console.log(err);
    }
    return referer;
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

/*Page events*/
window.onload = function () {
    try {

        var utcDateTime = getUTCDateTime();
        sessionStorage.setItem("startDateTime", utcDateTime);

        var startDateTime = new Date(sessionStorage.getItem("startDateTime"));

        var page = {
            MCMID: getMCMID(),
            sessionID: getUserSessionID(),
            pathName: getPathName(),
            url: getFullURL(),
            referer: getReferer(),
            startDateTime: startDateTime,
            endDateTime: '01/01/1900'
        };
        /*
        APICallBack(page);
        */
    }
    catch (err) {
        console.log(err);
    }

}

window.onbeforeunload = function () {
    try {
        //sessionStorage.setItem("pageUID",getUTCDateTime());
        var currentDateTime = getUTCDateTime();
        var startDateTime = new Date(sessionStorage.getItem("startDateTime"));

        var page = {
            MCMID: getMCMID(),
            sessionID: getUserSessionID(),
            pathName: getPathName(),
            url: getFullURL(),
            referer: getReferer(),
            startDateTime: startDateTime,
            endDateTime: currentDateTime
        };

        APICallBack(page);

    }
    catch (err) {
        console.log(err);
    }
}
