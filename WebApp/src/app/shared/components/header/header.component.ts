import { Component, Input, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  search: string = ""

  total: number = 0

  @Input()
  description: string = ""

  @Input()
  buttonDescription: string = ""

  @Input()
  modalToOpen: string = ""

  constructor() { }

  ngOnInit(): void {
  }

}
