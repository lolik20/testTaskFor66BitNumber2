import React, { Component, useEffect,useState} from 'react';
import axios from 'axios';

export function AllPlayers () {
  
  const [players,setPlayers]=useState([])
  const [name,setName]= useState();
    const [surName,setSurName]=useState();
    const [gender,setGender]=useState();
    const[bornDate,setBorn]=useState();
    const [displayStatus,setDisplayStatus]=useState('none')
    const [player,setPlayer]=useState([]);
    const[curPlayer,setCurPlayer]=useState();
  useEffect(()=>{
    console.log(name);
    getPlayers();
    
  })
  async function getPlayers() { 
    if(players.length<1)
    {
    const response = await fetch('api/player/all')
    const data = await response.json();
    
    setPlayers(data);
    }
  
  }  
  function savePlayer(){
    
    const body ={
      id:curPlayer,
        name:name,
        surName:surName,
        gender:gender,
        bornDate:bornDate

    }   
    axios.post('api/player/edit',body)
    .then(function(response)
    {
      setPlayers([]);
    getPlayers();
        console.log(response)
    })
    
}
 async function Edit(player)
 {
  const response = await fetch('api/player/'+player.id);
  const data = await response.json();
  setPlayer(data);
  
  setDisplayStatus('flex');
  setName(player.name);
  setSurName(player.surName);
  setGender(player.gender);
  setBorn(player.bornDate);
  setCurPlayer(player.id);
 }
  return (
<div>
      <table className='table table-striped' aria-labelledby="tabelLabel">
        
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Surname</th>
            <th>Gender  </th>
            <th>Born</th>
            <th>Team</th>
            <th>Country</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
        
          {players.map(player =>
            <tr key={player.id}>
              <td> {player.id}</td>
              
              <td>{player.name}</td>
              <td>{player.surName}</td>
              <td>{player.gender}</td>
              <td>{player.bornDate}</td>
              <td>{player.teamDTO.title}</td>
              <td>{player.teamDTO.country}</td>
              <td><button className="btn btn-primary" onClick={(e)=>Edit(player)}>Edit</button></td>
            </tr>
          )}
        </tbody>
      </table>
     
      <br/>
      <span className="text-dark">Сейчас изменяем игрока с id {curPlayer}</span>
      <div  style={{display:displayStatus}}>
            
            <div className="input-group mb-3">
              <div className="input-group-prepend">
                <span className="input-group-text" id="basic-addon1">Name</span>
              </div>
            <input id="name-input" className="form-control" aria-describedby="basic-addon1" onChange={(e)=>setName(e.target.value)} value={name}/>
            </div>
          
            <div className="input-group mb-3">
            <div className="input-group-prepend">
                <span className="input-group-text" id="basic-addon2">Surname</span>
              </div>
            <input id="surName-input" className="form-control" aria-describedby="basic-addon2" onChange={(e)=>setSurName(e.target.value)}  value={surName}/>
            </div>
          
            <div className="input-group mb-3">
            <div className="input-group-prepend">
                <span className="input-group-text" id="basic-addon3">Gender</span>
              </div>
            <input id="gender-input" className="form-control" aria-describedby="basic-addon3"onChange={(e)=>setGender(e.target.value)}   value={gender}/>
            </div>
            
            <div className="input-group mb-3">
            <div className="input-group-prepend">
                <span className="input-group-text" id="basic-addon4">Born Date</span>
              </div>
            <input id="bornDate-input" className="form-control" aria-describedby="basic-addon4" onChange={(e)=>setBorn(e.target.value)}  value={bornDate}/>
            </div>
            
            <button  className="btn btn-primary" onClick={()=>savePlayer()}>Save</button>
      </div>
      <button className="btn btn-success"><a className="text-dark " href="/"> Добавить футболиста</a></button>
    </div>
    );
  

 
}
