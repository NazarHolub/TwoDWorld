export class ApiResult {
    isSuccessFull: boolean;
    message: string;
}

export class ApiCollectionResult extends ApiResult {
    result: Array<any>;
}

export class ApiSingleResult extends ApiResult {
    result: any;
}