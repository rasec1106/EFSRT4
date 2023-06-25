import { Comment } from "./comment"
import { User } from "./user"

export class Post {
    postId?: number
    userId?: number
    title?: string
    content?: string
    imageUrl?: string
    publicationDate?: string
    comments?: Comment[]
    user?: User
}
