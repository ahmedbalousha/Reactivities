import { access } from 'fs/promises';
import React, { Fragment } from 'react';
import { Button, Header, Item, ItemGroup, Label, Segment } from 'semantic-ui-react';
import { Activity } from '../../app/models/activity';
interface Props {
  activities : Activity[];
}
export default function ActivityList ({activities}:Props) {
  return(
    <Segment>
      <ItemGroup divided>
        {activities.map(activity =>(
          <Item key ={activity.id}>
            <Item.Content>
              <Item.Header as='a'>{activity.titel}</Item.Header>
              <Item.Meta>{activity.date}</Item.Meta>
              <Item.Description>
                <div>{activity.discription}</div>
                <div>{activity.city},{activity.venue}</div>
              </Item.Description>
              <Item.Extra>
                <Button floated='right' content='View' color ='blue' />
                <Label basic content = {activity.category}/>
              </Item.Extra>
            </Item.Content>
            
          </Item>
        ))}

      </ItemGroup>
    </Segment>
  )
}
