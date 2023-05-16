let CompanyList = {
    "type": "object",
    "properties": {
        "data": {
            "type": "array",
            "items":
            {
                "type": "object",
                "properties": {
                    "company_id": {
                        "type": "integer"
                    },
                    "company_name": {
                        "type": "string"
                    },
                    "company_address": {
                        "type": "string"
                    },
                    "company_status": {
                        "type": "string",
                        "enum": ["ACTIVE", "CLOSED", "BANKRUPT"]
                    },
                    "description": {
                        "type": "string"
                    },
                    "description_lang": {
                        "type": "array",
                        "items":
                        {
                            "type": "object",
                            "properties": {
                                "translation_lang": {
                                    "type": "string"
                                },
                                "translation": {
                                    "type": "string"
                                }
                            },
                            "required": [
                                "translation_lang",
                                "translation"
                            ]
                        }

                    }
                },
                "required": [
                    "company_id",
                    "company_name",
                    "company_address",
                    "company_status"
                ]
            }
        },
        "meta": {
            "type": "object",
            "properties": {
                "limit": {
                    "type": "integer"
                },
                "offset": {
                    "type": "integer"
                },
                "total": {
                    "type": "integer"
                }
            },
            "required": [
                "total"
            ]
        }
    },
    "required": [
        "data",
        "meta"
    ]
};

pm.environment.set("CompanyList", JSON.stringify(CompanyList));

let Company = {
    "type": "object",
    "properties": {
        "company_id": {
            "type": "integer"
        },
        "company_name": {
            "type": "string"
        },
        "company_address": {
            "type": "string"
        },
        "company_status": {
            "type": "string",
            "enum": [ "ACTIVE", "BANKRUPT", "CLOSED" ]
        },
        "description": {
            "type": "string"
        },
        "description_lang": {
            "type": "array",
            "items":
            {
                "type": "object",
                "properties": {
                    "translation_lang": {
                        "type": "string",
                        "enum": [ "EN", "RU", "PL", "UA" ]
                    },
                    "translation": {
                        "type": "string"
                    }
                },
                "required": [
                    "translation_lang",
                    "translation"
                ]
            }

        }
    },
    "required": [
        "company_id",
        "company_name",
        "company_address",
        "company_status",
    ]
};

pm.environment.set("Company", JSON.stringify(Company));