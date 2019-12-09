import React from 'react';
import { Card, Icon, ButtonGroup, Button } from 'semantic-ui-react';


const ActivityDetails = () => {
 
 
    return (

        <Card fluid>
        
        <Card.Content>
          <Card.Header>title</Card.Header>
          <Card.Meta>
            <span >date</span>
          </Card.Meta>
          <Card.Description>
            description
          </Card.Description>
        </Card.Content>
        <Card.Content extra>
          <ButtonGroup widths={2}>
              <Button basic color = 'blue' content='Edit' />
              <Button basic color = 'red' content='Cancle' />
          </ButtonGroup>
        </Card.Content>
      </Card>
     
    );


  }


export default ActivityDetails;


