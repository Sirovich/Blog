export class Comment {
    constructor(
        public id: number,
        public text: string,
        public postId: number,
        public createdUser: string,
        public createdDate: string
    ) { }
}