import React, {  useEffect, useState } from 'react';
import { Header, Icon, List, Container } from 'semantic-ui-react'
import axios from 'axios';
import { IActivity } from '../models/activity';
import NavBar from '../../features/nav/NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';



const App = () => {
 
  const [activities, setActivities] = useState<IActivity[]>([]);
 
  useEffect(() => {
    axios
    .get<IActivity[]>('http://localhost:5000/api/activities/list')
    .then(response => {
        setActivities(response.data)
      });
    }, []);

    return (
      <div>
         <NavBar />
         <Container style={{marginTop: '7em'}}>
            <ActivityDashboard activities= {activities} />
         </Container>
      
      </div>
    );


  }


export default App;


