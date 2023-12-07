import { RepoItem } from "./RepoItem";

export class Recipe extends RepoItem {
    constructor(data) {
        super(data)
        this.title = data.title
        this.img = data.img
        this.instructions = data.instructions
        this.category = data.category
        this.creator = data.creator
        this.creatorId = data.creatorId

    }
}

const data = {
    "title": "The Senior Jake Burrito",
    "instructions": "Take your burrito and cook it, then add hotdog.  Boom, Burrito.",
    "img": "https://images.unsplash.com/photo-1584031036380-3fb6f2d51880?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
    "category": "Mexican",
    "creatorId": "6541827fc58db642d7c02476",
    "creator": {
        "picture": "https://images.unsplash.com/photo-1621592484082-2d05b1290d7a?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8a2V2aW58ZW58MHx8MHx8fDA%3D",
        "name": "me",
        "id": "6541827fc58db642d7c02476",
        "createdAt": "2023-11-29T22:54:57",
        "updatedAt": "2023-12-04T22:41:59"
    },
    "id": 46,
    "createdAt": "2023-11-30T23:46:44",
    "updatedAt": "2023-11-30T23:46:44"
}