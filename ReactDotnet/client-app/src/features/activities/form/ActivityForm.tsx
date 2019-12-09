import { Segment, Form } from "semantic-ui-react"
import React from "react"

const ActivityForm = () => {
    return(
        <Segment>
            <Form>
                <Form.Input placeholder='title' />
                <Form.TextArea rows={2} placeholder='description' />
                <Form.Input placeholder='category' />
                <Form.Input type='date' placeholder='date' />
                <Form.Input placeholder='city' />
                <Form.Input placeholder='vanue' />
            </Form>
        </Segment>
    )
}

export default ActivityForm;