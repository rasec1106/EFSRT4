import { User } from "./user"

export class Comment {
    commentId?: number
    userId?: number
    user?: User
    content?: string
    publicationDate?: string
    postId?: number
}
