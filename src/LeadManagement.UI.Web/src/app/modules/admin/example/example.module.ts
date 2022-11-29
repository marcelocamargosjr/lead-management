import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { ExampleComponent } from 'app/modules/admin/example/example.component';
import { MatTabsModule } from '@angular/material/tabs';
import { FuseCardModule } from '@fuse/components/card';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

const exampleRoutes: Route[] = [
    {
        path: '',
        component: ExampleComponent
    }
];

@NgModule({
    declarations: [
        ExampleComponent
    ],
    imports: [
        RouterModule.forChild(exampleRoutes),
        MatTabsModule,
        FuseCardModule,
        MatIconModule,
        CommonModule
    ]
})
export class ExampleModule {
}
