import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {EventService} from "../../services/events-service";
import {IEvent} from "../../interfaces/IEvent";

export var log = LogManager.getLogger('Events.Delete');

@autoinject
export class Delete {

  private event: IEvent;

  constructor(
    private router: Router,
    private eventsService: EventService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.eventsService.delete(this.event.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("EventsIndex");
      } else {
        log.debug('response', response);
      }
    });
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');

  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.eventsService.fetch(params.id).then(
      event => {
        log.debug('event', event);
        this.event = event;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
