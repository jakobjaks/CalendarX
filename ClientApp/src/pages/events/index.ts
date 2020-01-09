import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IEvent} from "../../interfaces/IEvent";
import {EventService} from "../../services/events-service";
import {BaseService} from "../../services/base-service";

export var log = LogManager.getLogger('Event.Index');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

    private Event: IEvent[] = [];
    private category: number = 1;
    private searchString: string = "";

    constructor(
        private EventService: EventService
    ) {
        log.debug('constructor');
    }

    submit() {
        this.EventService.fetchBySearch(this.searchString, this.category).then(
            jsonData => {
                log.debug('jsonData', jsonData);
                this.Event = jsonData;
            }
        );
    }

    getPast() {
        this.EventService.fetchPast().then(
            jsonData => {
                log.debug('jsonData', jsonData);
                this.Event = jsonData;
            }
        );
    }

    // ============ View LifeCycle events ==============
    created(owningView: View, myView: View) {
        log.debug('created');
    }

    bind(bindingContext: Object, overrideContext: Object) {
        log.debug('bind');
    }

    attached(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        log.debug('attached');
        this.EventService.fetchAll().then(
            jsonData => {
                log.debug('jsonData', jsonData);
                this.Event = jsonData;
            }
        );
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
        log.debug('activate' + params.id);
        if (params.id != null && params.name != null) {
            this.EventService.fetchBySearch(params.name, params.id).then(
                jsonData => {
                    log.debug('jsonData', jsonData);
                    this.Event = jsonData;
                }
            );
        }

    }

    canDeactivate() {
        log.debug('canDeactivate');
    }

    deactivate() {
        log.debug('deactivate');
    }
}
