import { Comment } from "./comment";
import { Like } from "./like";

export interface PostDetail {
    id: number,
    userId: number,
    title: string,
    body: string,
    groupId: number,
    comments: Comment[],
    likes: Like[]

}