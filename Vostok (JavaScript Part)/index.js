var cities = [
    {id: 0, name: "Moscow", idsWorkshops: [0, 1]},
    {id: 1, name: "Syktyvkar", idsWorkshops: [1]},
    {id: 2, name: "Ekaterinburg", idsWorkshops: [0, 1, 2]},
    {id: 3, name: "St. Petersburg", idsWorkshops: [1,2]},
    {id: 4, name: "Irkutsk", idsWorkshops: [1, 3]},
    {id: 5, name: "Vladivostok", idsWorkshops: [2]},
    {id: 6, name: "Saratov", idsWorkshops: [0,2]},
    {id: 7, name: "Sochi", idsWorkshops: [1,0]},
];

var workshops = [
    {id: 0, name: "Workshop 0", idsEmployees: [1, 5]},
    {id: 1, name: "Workshop 1", idsEmployees: [1,4,7]},
    {id: 2, name: "Workshop 2", idsEmployees: [2,3]},
    {id: 3, name: "Workshop 3", idsEmployees: [2,4,5,6,7]},
];

var employees = [
    {id: 0, name: "Human 0"},
    {id: 1, name: "Human 1"},
    {id: 2, name: "Human 2"},
    {id: 3, name: "Human 3"},
    {id: 4, name: "Human 4"},
    {id: 5, name: "Human 5"},
    {id: 6, name: "Human 6"},
    {id: 7, name: "Human 7"},
];

var brigade = [
    {id: 0, name: "Brigade 0", start: 8, end: 20},
    {id: 1, name: "Brigade 1", start: 20, end: 8}
];

window.onload = function exampleFunction() {
    var citySelect = document.getElementById('city');
    var workshopSelect = document.getElementById('workshop');
    var employeeSelect = document.getElementById('employee');
    var brigadeLabel = document.getElementById('brigade');
    var changeSelect = document.getElementById('change');

    // init city select
    citySelect.innerHTML = cities.map(city => createOption(city.id, city.name)).join("\n");;

    citySelect.addEventListener('change', function(){    
        // init workshop select
        var optionsWorkshops = workshops
        .filter(w => cities.filter(c => c.id == this.value)[0].idsWorkshops.includes(w.id))
        .map(workshop => createOption(workshop.id, workshop.name)).join("\n");

        workshopSelect.innerHTML = optionsWorkshops;

        // call onchange on workshop select element
        workshopSelect.dispatchEvent(new Event('change'));
    });

    workshopSelect.addEventListener('change', function(){    
        // init workshop select
        var optionsEmployees = employees
        .filter(e => workshops.filter(w => w.id == this.value)[0].idsEmployees.includes(e.id))
        .map(employees => createOption(employees.id, employees.name)).join("\n");

        employeeSelect.innerHTML = optionsEmployees;

        // call onchange on employee select element
        employeeSelect.dispatchEvent(new Event('change'));
    });

    employeeSelect.addEventListener('change', function(){  
        // init brigade select
        var hours = new Date().getHours(); 
        var rightBrigade = hours > 8 && hours < 20 ? brigade[0] : brigade[1];
        brigadeLabel.innerHTML = `${rightBrigade.name} (${rightBrigade.start}-${rightBrigade.end})`;
        
        // calculate intervals of changes
        var changes = [];
        for (let loop = 8, start = rightBrigade.start; (start + loop) % 24 <= rightBrigade.end; start++) {
            changes.push(`${start % 24}-${(start + loop) % 24}`);
        }

        // init change select
        changeSelect.innerHTML = changes.map((change, index) => createOption(index, change)).join("\n");
    });

    // call to init all.
    citySelect.dispatchEvent(new Event('change'));
}

function createOption(value, inner){
    return `<option value=${value}>${inner}</option>`;
}