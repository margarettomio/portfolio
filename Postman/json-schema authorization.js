let MeResponse = {
    "type": "object",
    "properties": {
        "token": {
            "type": "string"
        },
        "user_name": {
            "type": "string"
        },
        "email_address": {
            "type": "string",
            "format": "email"
        },
        "valid_till": {
            "type": "string",
            "format": "date-time"
        }
    },
    "required": [
        "token",
        "user_name",
        "email_address",
        "valid_till"
    ]
};

pm.environment.set("MeResponse", JSON.stringify(MeResponse));