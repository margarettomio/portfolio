let HTTPValidationError = {
    "type": "object",
    "properties": {
        "detail": {
            "type": "array",
            "items":
            {
                "type": "object",
                "properties": {
                    "loc": {
                        "type": "array",
                        "items": {
                            "type": [
                                "string",
                                "integer"
                            ]
                        }
                    },
                    "msg": {
                        "type": "string"
                    }
                },
                "required": [
                    "loc",
                    "msg",
                    "type"
                ]
            }
        }
    },
    "required": [
        "detail"
    ]
};

pm.environment.set("HTTPValidationError", JSON.stringify(HTTPValidationError));