
import React,{useState,useEffect}from 'react';
import axios from 'axios'
export function AddPlayer()
{
    const [name,setName]= useState("");
    const [surName,setSurName]=useState("");
    const [gender,setGender]=useState(1);
    const [yyyy,setYY]= useState(null);
    const[mm,setMM]=useState(null);
    const[dd,setDD]=useState(null);
        const [teamChoosed, setTeam]=useState(null);
    const [teams,setTeams]=useState([]);
    const [countryChoosed,setCountry]=useState();
    
    useEffect(()=>{
   
        getTeams();
    }

    );

    async function getTeams() { 
        if(teams.length<1)
        {
        const response = await fetch('api/team/all');
        const data = await response.json();
        setTeams(data);
        }
      }
    function setTeamAndCountry(event)
    {
        setTeam(event.target.value.split('+')[0]);
        setCountry(event.target.value.split('+')[1]);

    }
    function formSubmit(e){
        e.preventDefault();
        const body ={
            name:name,
            surName:surName,
            gender:gender,
            bornDate:yyyy+'-'+mm+'-'+dd,
            title:teamChoosed,
            country:countryChoosed
        }   
        axios.post('api/player/add',body)
        .then(function(response)
        {
            console.log(response)
        })
        
    }
    return (
        <div>
        <form onSubmit={formSubmit}>
            <div className="form-group">
                <label for="name-input">Имя:</label>
                <input type="text" id="name-input" onChange={(e)=>setName(e.target.value)} className="form-control" required/>

            </div>
            <div className="form-group">
                <label for="surName-input">Фамилия</label>
                <input type="text" id="surName-input" onChange={(e)=>setSurName(e.target.value)} className="form-control" required/>
                
            </div>
            <div className="form-group">
                <label for="gender-input">Пол</label>
               <select onChange={(e)=>setGender(e.target.value)}  className="form-control">
                   <option value={"male"}>Мужчина</option>
                   <option value={"female"}>Женщина</option>
               </select>
            </div>
            <div className="form-group">
                <label for="date-input">Дата рождения</label>
                <div className="input-group">
                    <div className="input-group-prepend">
                        <span id="year-addon" className="input-group-text">Год</span>
                    </div>
                    <input  onChange={(e)=>setYY(e.target.value)} type="number" className="form-control" id="date-input" aria-describedby="year-addon" required/>
                    <div className="input-group-prepend">
                        <span id="month-addon" className="input-group-text">Месяц</span>
                    </div>
                    <input  onChange={(e)=>setMM(e.target.value)} type="number" className="form-control" id="month-input" aria-describedby="month-addon" required/>
                    <div className="input-group-prepend">
                        <span id="day-addon" className="input-group-text">День</span>
                    </div>
                    <input  onChange={(e)=>setDD(e.target.value)} type="number" className="form-control" id="day-input" aria-describedby="day-addon" required/>
                    
                </div>
            </div>
            <div className="form-group">
                <label for="team-input" >Название команды</label>
                <select className="form-control" onChange={(e)=>setTeamAndCountry(e)} onClick={(e)=>setTeamAndCountry(e)} >
                 {teams.map(team=>
                    <option  value={team.title+"+"+team.country}>{team.title}</option>
                 )}
               </select>
                <input type="text" id="team-input" value={teamChoosed} onChange={(e)=>setTeam(e.target.value)}  className="form-control"  required aria-describedby="teamHelp"></input>
                <small id="teamHelp" class="form-text text-muted">Чтобы добавить другую команду введите название</small>
            </div>
                    
            <div className="form-group">
                <label for="country-input">Выбор страны</label>
                <select className="form-control"onChange={(e)=>setCountry(e.target.value)} >
                    <option value={"Russia"}>Russia</option>
                    <option value={"USA"}>USA</option>
                    <option value={"Italy"}>Italy</option>
                </select>
                <input className="form-control" id="country-input" value={countryChoosed} readOnly></input>
            </div>
            <div className="form-group">
            <button type="submit" className="btn btn-primary mb-10">Добавить</button>
            </div>
            
        </form>
        
        </div>
        
    );
    
   
}