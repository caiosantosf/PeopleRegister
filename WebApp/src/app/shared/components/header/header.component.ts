import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { debounceTime, distinctUntilChanged, filter, fromEvent, tap } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements AfterViewInit {

  search: string = ""
  total: number = 0

  @ViewChild('inputSearch') inputSearch!: ElementRef;
  @Output("callback") callback: EventEmitter<any> = new EventEmitter()
  @Input() description: string = ""
  @Input() buttonDescription: string = ""
  @Input() modalToOpen: string = ""

  constructor() { }

  ngAfterViewInit(): void {
    fromEvent(this.inputSearch.nativeElement, 'keyup')
      .pipe(
          filter(Boolean),
          debounceTime(150),
          distinctUntilChanged(),
          tap(_ => {
            this.callback.emit({ search: this.search })
          })
      )
      .subscribe();
  }

}
