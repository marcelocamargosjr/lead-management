import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'example',
    templateUrl: './example.component.html',
    encapsulation: ViewEncapsulation.None
})
export class ExampleComponent implements OnInit {
    invited: any[] = [];
    accepted: any[] = [];

    /**
     * Constructor
     */
    constructor(private _httpClient: HttpClient) {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this.getAllInvited();
        this.getAllAccepted();
    }

    /**
     * Get all invited
     */
    getAllInvited() {
        this._httpClient.get<any[]>('https://lead-management-api.azurewebsites.net/api/v1/leads/invited').subscribe(response => this.invited = response);
    }

    /**
     * Get all accepted
     */
    getAllAccepted() {
        this._httpClient.get<any[]>('https://lead-management-api.azurewebsites.net/api/v1/leads/accepted').subscribe(response => this.accepted = response);
    }

    /**
     * Accept
     */
    accept(id: any) {
        this._httpClient.patch(`https://lead-management-api.azurewebsites.net/api/v1/leads/${id}/accept`, null).subscribe({
            next: () => {
                this.getAllInvited();
                this.getAllAccepted();
            }
        });
    }

    /**
      * Decline
      */
    decline(id: any) {
        this._httpClient.patch(`https://lead-management-api.azurewebsites.net/api/v1/leads/${id}/decline`, null).subscribe({
            next: () => {
                this.getAllInvited();
                this.getAllAccepted();
            }
        });
    }
}
