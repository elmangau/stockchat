import './ChatMessages.css';
import * as React from 'react';
import { useState } from 'react';

import * as Utils from './Utils';
import { Button, Container, Row, Col, ListGroup, InputGroup, FormControl } from "react-bootstrap";
import { RouteComponentProps } from 'react-router';
import { ChatMessage } from './Models/ChatMessage';

export interface ChatMessagesProps extends RouteComponentProps<any> {
}

const ChatMessages = ({ }: ChatMessagesProps) => {
    const [messages, setMessages] = useState<ChatMessage[]>([]);
    const [message, setMessage] = useState<string>("");

    function onRefreshMessagesClick(event: React.FormEvent) {
        
        event.preventDefault();
        Utils.getMessagesFetch()
            .then((messages: ChatMessage[]) => {
                setMessages(messages);
            });
    }

    function onSendMessageClick(event: React.FormEvent) {
        if (message.length > 0) {
            let msg = message;
            setMessage("");
            event.preventDefault();
            Utils.sendMessageFetch(msg)
                .then(() => {
                    Utils.getMessagesFetch()
                        .then((messages: ChatMessage[]) => {
                            setMessages(messages);
                        });
                });
        }
    }

    let dateFormat = new Intl.DateTimeFormat('en-US', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit',
        hour12: true
    });

    /*function refreshMessages() {
        Utils.getMessagesFetch()
            .then((messages: ChatMessage[]) => {
                setMessages(messages);

                setTimeout(() => refreshMessages(), 10000);
            });
    }*/

    // refreshMessages();

    return (
        <Container className="ChatMessages">
            <Row>
                <Col sm={12} lg={12}>
                    <InputGroup className="mb-3">
                        <FormControl
                            placeholder="Type message to send"
                            aria-label="Type message to send"
                            aria-describedby="basic-addon2"
                            value={message}
                            onChange={(e: any) => setMessage(e.target.value)}
                        />
                        <InputGroup.Append>
                            <Button size="sm" variant="success" onClick={onSendMessageClick}>Send</Button>
                            <Button size="sm" variant="info" onClick={onRefreshMessagesClick}>Refresh</Button>
                        </InputGroup.Append>
                    </InputGroup>
                </Col>
            </Row>
            <Row>
                <Col sm={12} lg={12}>
                    <ListGroup>
                        {
                            messages.map((message) => {
                                return (
                                    <ListGroup.Item as="li">
                                        {dateFormat.format(new Date(message.postedOn.replace('Z', '') + 'Z'))} -> {message.postedBy} -> {message.message}
                                    </ListGroup.Item>
                                );
                            })
                        }
                    </ListGroup>
                </Col>
            </Row>
        </Container>
    );
}

export default ChatMessages;
