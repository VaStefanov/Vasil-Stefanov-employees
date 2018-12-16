let employees = [];
let d = new Date();
//object generator
function employee(EmpId, ProjectID, DateFrom, DateTo) {
    this.EmpId = EmpId;
    this.ProjectID = ProjectID;
    this.DateFrom = DateFrom;
    if (DateTo == "NULL") {
        const month = d.getMonth() + 1;
        this.DateTo = d.getFullYear() + "-" + month + "-" + d.getDate();
    } else {
        this.DateTo = DateTo;
    }
    const startDate = new Date(this.DateFrom);
    const endDate = new Date(this.DateTo);
    const timeSpan = ((endDate.getTime() - startDate.getTime()) / 1000) / (3600 * 24);
    this.duration = timeSpan;
}

//fetch text file
var request = new XMLHttpRequest();
request.open("GET", "employees.txt");
request.onload = function () {
    let data = request.responseText;
    const lines = data.split('\n');
    for (let i = 0; i < lines.length; i++) {
        //split words
        let words = lines[i].split(', ');
        //create and push objects
        const employeeObj = new employee(words[0], words[1], words[2], words[3].trim());
        employees.push(employeeObj)
    }
}
request.send();
            


//find pairs
function longestWorkingPair(employees) {
    $("#output").append("Pair of employees that have worked for the longest period of time on a single project" + "<br/>");
    let totalDays = 0;
    let foundPair = false;
    let firstEmployee;
    let firstEmployeeDuration;
    let secondEmployee;
    let secondEmployeeDuration;
    let firstEmpProjId;
    let secondEmpProjId;
    for (let i = 0; i < employees.length; i++) {
        for (let j = 0; j < employees.length; j++) {
            let totalDuration = employees[i].duration + employees[j].duration;
            if (employees[i].EmpId != employees[j].EmpId && employees[i].ProjectID == employees[j].ProjectID && totalDuration > totalDays) {
                totalDays = totalDuration;
                firstEmployee = employees[i].EmpId;
                firstEmployeeDuration = employees[i].duration;
                secondEmployee = employees[j].EmpId;
                secondEmployeeDuration = employees[j].duration;
                firstEmpProjId = employees[i].ProjectID;
                secondEmpProjId = employees[j].ProjectID;
                foundPair = true;
            }
        }
    }
    if (foundPair) {
        $("main").append("Employee with id " + firstEmployee + " " + "has worked for " + firstEmployeeDuration + " " + "days " + "on project " + firstEmpProjId + "<br/>" + "Employee with id " + secondEmployee + " " + "has worked for " + secondEmployeeDuration + " " + "days " + "on project " + secondEmpProjId);

        console.log("Employee with id " + firstEmployee + " " + "has worked for " + firstEmployeeDuration + " " + "days " + "on project " + firstEmpProjId + "\n" + "Employee with id " + secondEmployee + " " + "has worked for " + secondEmployeeDuration + " " + "days " + "on project " + secondEmpProjId);
    }
}

setTimeout(() => {
    longestWorkingPair(employees);
}, 500);
