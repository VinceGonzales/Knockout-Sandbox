(function () {
    var button = document.querySelector('.btn');
    var input = document.querySelector('.form-control');
    var heading = document.querySelector('.headline');
    var flexibleArray = ['John Doe', 24, true];
    var Status;
    (function (Status) {
        Status[Status["Started"] = 33] = "Started";
        Status[Status["InProgress"] = 66] = "InProgress";
        Status[Status["Completed"] = 100] = "Completed";
    })(Status || (Status = {}));
    var status = Status.InProgress;
    console.log("The project is ", status, "% completed.");
    button.addEventListener('click', handleButtonClick);
    var settings = { width: 1920, height: 1080 };
    console.log("Display settings: ", settings);
})();
function handleButtonClick(evtObject) {
    evtObject.preventDefault();
    var btn = evtObject.target;
    console.log(btn.innerHTML);
}
//# sourceMappingURL=C:/Users/LADBSCID11/Source/Repos/Knockout-Sandbox/Knockout-Sandbox/Xolartek.Knockout/Xolartek.Web/Scripts/typescripts/main.js.map