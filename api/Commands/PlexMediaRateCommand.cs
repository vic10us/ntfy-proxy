﻿using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexMediaRateCommand : IRequest
{
    public PlexMediaRateCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
