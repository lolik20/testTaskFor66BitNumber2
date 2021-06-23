import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import {AllPlayers} from './components/AllPlayers'
import './custom.css'
import { AddPlayer } from './components/AddPlayer';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={AddPlayer} />
        <Route path="/all-players" component={AllPlayers}/>
        
        
      </Layout>
    );
  }
}
