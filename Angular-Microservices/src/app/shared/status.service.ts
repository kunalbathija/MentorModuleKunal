import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class StatusService {
    success!: boolean;
    errorMessage!: string;
}