"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("./ChatMessages.css");
var React = require("react");
var react_1 = require("react");
var Utils = require("./Utils");
var react_bootstrap_1 = require("react-bootstrap");
var ChatMessages = function (_a) {
    var _b = react_1.useState([]), messages = _b[0], setMessages = _b[1];
    var _c = react_1.useState(""), message = _c[0], setMessage = _c[1];
    function onRefreshMessagesClick(event) {
        event.preventDefault();
        Utils.getMessagesFetch()
            .then(function (messages) {
            setMessages(messages);
        });
    }
    function onSendMessageClick(event) {
        if (message.length > 0) {
            var msg = message;
            setMessage("");
            event.preventDefault();
            Utils.sendMessageFetch(msg)
                .then(function () {
                Utils.getMessagesFetch()
                    .then(function (messages) {
                    setMessages(messages);
                });
            });
        }
    }
    var dateFormat = new Intl.DateTimeFormat('en-US', {
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
    return (React.createElement(react_bootstrap_1.Container, { className: "ChatMessages" },
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement(react_bootstrap_1.Col, { sm: 12, lg: 12 },
                React.createElement(react_bootstrap_1.InputGroup, { className: "mb-3" },
                    React.createElement(react_bootstrap_1.FormControl, { placeholder: "Type message to send", "aria-label": "Type message to send", "aria-describedby": "basic-addon2", value: message, onChange: function (e) { return setMessage(e.target.value); } }),
                    React.createElement(react_bootstrap_1.InputGroup.Append, null,
                        React.createElement(react_bootstrap_1.Button, { size: "sm", variant: "success", onClick: onSendMessageClick }, "Send"),
                        React.createElement(react_bootstrap_1.Button, { size: "sm", variant: "info", onClick: onRefreshMessagesClick }, "Refresh"))))),
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement(react_bootstrap_1.Col, { sm: 12, lg: 12 },
                React.createElement(react_bootstrap_1.ListGroup, null, messages.map(function (message) {
                    return (React.createElement(react_bootstrap_1.ListGroup.Item, { as: "li" },
                        dateFormat.format(new Date(message.postedOn.replace('Z', '') + 'Z')),
                        " -> ",
                        message.postedBy,
                        " -> ",
                        message.message));
                }))))));
};
exports.default = ChatMessages;
//# sourceMappingURL=ChatMessages.js.map