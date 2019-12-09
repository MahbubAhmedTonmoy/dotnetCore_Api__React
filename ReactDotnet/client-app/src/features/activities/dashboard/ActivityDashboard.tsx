import React from 'react';
import { Grid, List, GridColumn } from 'semantic-ui-react';
import { IActivity } from '../../../app/models/activity';
import ActivityList from './ActivityList';
import AactivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';

interface IProps {
    activities : IActivity[]
}

const ActivityDashboard: React.FC<IProps> = ({activities}) => {
    return (
        <Grid>
            <Grid.Column width={10}>
                <ActivityList activities= {activities}/>
            </Grid.Column>
            <GridColumn width ={6}>
                <AactivityDetails />
                <ActivityForm />
            </GridColumn>
        </Grid>
    );
};

export default ActivityDashboard