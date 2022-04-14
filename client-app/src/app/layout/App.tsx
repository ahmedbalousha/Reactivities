import React, { Fragment, useEffect, useState } from 'react';
//import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/dashboard/ActivityDashboard';
import axios from 'axios';

function App() {
  const [activities, setActivities] = useState<Activity[]> ([]);

  useEffect (() => {
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  },[])
  return (
      <Fragment>
        <NavBar/>
      <Container style={{marginTob:'7em'}}>
        <ActivityDashboard activities ={activities}/>
      <List>
      {activities.map(activity =>(
          <List.Item key= {activity.id}>
                      {activity.titel}

          </List.Item>
      ))}

      </List>
      </Container></Fragment>
     
  );
}

export default App;