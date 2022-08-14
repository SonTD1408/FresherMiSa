import axios from "axios";


var axiosConfig = {
    Nations: "http://localhost:5091/api/Nation",
    Cities: "http://localhost:5091/api/City",
    Districts: "http://localhost:5091/api/District",
    Wards: "http://localhost:5091/api/Ward",
    Potentials: "http://localhost:5091/api/Potential",
    Careers: "http://localhost:5091/api/Career",
    PotentialTypes: "http://localhost:5091/api/PotentialType",
    Vocatives: "http://localhost:5091/api/Vocative",
    Sources: "http://localhost:5091/api/Source",
    OrganizationTypes: "http://localhost:5091/api/OrganizationType",
    Fields: "http://localhost:5091/api/Field",
    Departments: "http://localhost:5091/api/Department",
    Positions: "http://localhost:5091/api/Position", 
    Turnovers: "http://localhost:5091/api/Turnover",
    MultiDelete: "http://localhost:5091/api/Potential/MultiDelete"
}

axiosConfig.call = (method, url, data, fnCallBack)=>{

    axios[method](url,data,{
        headers: {
            'Content-Type': 'application/json',
        }
    })
    .then((response)=>{
        fnCallBack(response);
    })
    .catch((error)=>{
        console.log(error);
    })
}

export default axiosConfig;