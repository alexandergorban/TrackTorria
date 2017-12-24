import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html',
    styleUrls: ['./counter.component.css']
})
export class CounterComponent {
    public currentCount = 0;
    public isEnable = true;

    public incrementCounter() {
        this.currentCount++;
    }
}
